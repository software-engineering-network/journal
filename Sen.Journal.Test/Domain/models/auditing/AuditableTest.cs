using System;
using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain
{
    public class AuditableTest
    {
        [Fact]
        public void WhenUpdating_ANewAuditable_ItSetsBothCreatedAndModifiedProperties()
        {
            var currentUserProvider = TestServiceFactory.CreateCurrentUserProvider();
            var now = DateTime.Now;
            var dateTimeProvider = TestServiceFactory.CreateDateTimeProvider(now);
            var currentUserId = currentUserProvider.CurrentUser.Id;

            var auditable = new Auditable(
                currentUserProvider,
                dateTimeProvider
            );

            auditable.Update();

            auditable.CreatedBy.Should().Be(currentUserId);
            auditable.CreatedDate.Should().Be(now);
            auditable.ModifiedBy.Should().Be(currentUserId);
            auditable.ModifiedDate.Should().Be(now);
        }

        [Fact]
        public void WhenUpdating_AnExistingAuditable_ItOnlySetsModifiedProperties()
        {
            var testCurrentUserProvider = TestServiceFactory.CreateCurrentUserProvider();
            var createdBy = TestUserFactory.CreateJohnDoe(1);
            var modifiedBy = TestUserFactory.CreateJaneDoe(1);

            var now = DateTime.Now;
            var anHourAgo = now.AddHours(-1);
            var testDateTimeProvider = TestServiceFactory.CreateDateTimeProvider(anHourAgo);

            var auditable = new Auditable(
                testCurrentUserProvider,
                testDateTimeProvider
            );

            // first create
            auditable.Update();

            // attempt second create
            testCurrentUserProvider.CurrentUser = modifiedBy;
            testDateTimeProvider.DateTimeToProvide = now;
            auditable.Update();

            auditable.CreatedBy.Should().Be(createdBy.Id);
            auditable.CreatedDate.Should().Be(anHourAgo);
            auditable.ModifiedBy.Should().Be(modifiedBy.Id);
            auditable.ModifiedDate.Should().Be(now);
        }
    }
}

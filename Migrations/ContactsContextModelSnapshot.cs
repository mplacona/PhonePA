using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using PhonePA.Models;

namespace PhonePAMigrations
{
    [ContextType(typeof(ContactsContext))]
    partial class ContactsContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("PhonePA.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Blocked");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Key("ContactId");
                });
        }
    }
}

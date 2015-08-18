using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using PhonePA.Models;

namespace PhonePAMigrations
{
    [ContextType(typeof(ContactsContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20150817131203_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
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

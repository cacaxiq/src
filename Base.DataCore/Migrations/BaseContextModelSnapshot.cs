﻿// <auto-generated />
using Base.Domain.Enums;
using Base.ExternalData.Context;
using Base.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Base.ExternalData.Migrations
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Base.Domain.Entities.Intention", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bedroom");

                    b.Property<int>("PropertySituation");

                    b.Property<int>("PropertyType");

                    b.Property<Guid?>("ProspectId");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ProspectId");

                    b.ToTable("Intention");
                });

            modelBuilder.Entity("Base.Domain.Entities.Prospect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Prospect");
                });

            modelBuilder.Entity("Base.Domain.Entities.Intention", b =>
                {
                    b.HasOne("Base.Domain.Entities.Prospect", "Prospect")
                        .WithMany("Intentions")
                        .HasForeignKey("ProspectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Base.Domain.ValueObjects.Place", "Place", b1 =>
                        {
                            b1.Property<Guid>("IntentionId");

                            b1.Property<string>("City");

                            b1.Property<string>("Neighborhood");

                            b1.Property<int>("State");

                            b1.ToTable("Intention");

                            b1.HasOne("Base.Domain.Entities.Intention")
                                .WithOne("Place")
                                .HasForeignKey("Base.Domain.ValueObjects.Place", "IntentionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Base.Domain.ValueObjects.PriceRange", "PriceRange", b1 =>
                        {
                            b1.Property<Guid>("IntentionId");

                            b1.Property<decimal>("LowestPrice");

                            b1.Property<decimal>("MaximumPrice");

                            b1.ToTable("Intention");

                            b1.HasOne("Base.Domain.Entities.Intention")
                                .WithOne("PriceRange")
                                .HasForeignKey("Base.Domain.ValueObjects.PriceRange", "IntentionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Base.Domain.Entities.Prospect", b =>
                {
                    b.OwnsOne("Base.Shared.Domain.ValueObjects.CellPhone", "CellPhone", b1 =>
                        {
                            b1.Property<Guid>("ProspectId");

                            b1.Property<bool>("IsWhatsApp");

                            b1.Property<string>("Number");

                            b1.ToTable("Prospect");

                            b1.HasOne("Base.Domain.Entities.Prospect")
                                .WithOne("CellPhone")
                                .HasForeignKey("Base.Shared.Domain.ValueObjects.CellPhone", "ProspectId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Base.Shared.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ProspectId");

                            b1.Property<string>("Address");

                            b1.ToTable("Prospect");

                            b1.HasOne("Base.Domain.Entities.Prospect")
                                .WithOne("Email")
                                .HasForeignKey("Base.Shared.Domain.ValueObjects.Email", "ProspectId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Base.Shared.Domain.ValueObjects.HomePhone", "HomePhone", b1 =>
                        {
                            b1.Property<Guid>("ProspectId");

                            b1.Property<string>("Number");

                            b1.ToTable("Prospect");

                            b1.HasOne("Base.Domain.Entities.Prospect")
                                .WithOne("HomePhone")
                                .HasForeignKey("Base.Shared.Domain.ValueObjects.HomePhone", "ProspectId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Base.Shared.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("ProspectId");

                            b1.Property<string>("FirstName");

                            b1.Property<string>("LastName");

                            b1.ToTable("Prospect");

                            b1.HasOne("Base.Domain.Entities.Prospect")
                                .WithOne("Name")
                                .HasForeignKey("Base.Shared.Domain.ValueObjects.Name", "ProspectId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

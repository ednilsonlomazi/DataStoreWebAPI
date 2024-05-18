﻿// <auto-generated />
using System;
using DataStoreWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    [DbContext(typeof(DbDataStoreContext))]
    [Migration("20240518200847_m07573")]
    partial class m07573
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabAvaliacao", b =>
                {
                    b.Property<int>("codigoAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoAvaliacao"));

                    b.Property<int?>("TabItemDocumentocodigoDocumento")
                        .HasColumnType("int");

                    b.Property<int?>("TabItemDocumentocodigoItemDocumento")
                        .HasColumnType("int");

                    b.Property<DateTime>("dtaAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("justificativa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("resultado")
                        .HasColumnType("bit");

                    b.HasKey("codigoAvaliacao");

                    b.HasIndex("TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento");

                    b.ToTable("tabAvaliacao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabAvaliador", b =>
                {
                    b.Property<int>("codigoAvaliador")
                        .HasColumnType("int");

                    b.HasKey("codigoAvaliador");

                    b.ToTable("tabAvaliador");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabCliente", b =>
                {
                    b.Property<int>("codigoCliente")
                        .HasColumnType("int");

                    b.HasKey("codigoCliente");

                    b.ToTable("tabCliente");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabDocumento", b =>
                {
                    b.Property<int>("codigoDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoDocumento"));

                    b.Property<string>("avaliadorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("clienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("dataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("isOpen")
                        .HasColumnType("bit");

                    b.HasKey("codigoDocumento");

                    b.HasIndex("avaliadorId");

                    b.HasIndex("clienteId");

                    b.ToTable("tabDocumento");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumento", b =>
                {
                    b.Property<int>("codigoDocumento")
                        .HasColumnType("int");

                    b.Property<int>("codigoItemDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoItemDocumento"));

                    b.Property<int>("codigoPermissao")
                        .HasColumnType("int");

                    b.HasKey("codigoDocumento", "codigoItemDocumento");

                    b.ToTable("tabItemDocumento");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumentoObjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("tabItemDocumentocodigoDocumento")
                        .HasColumnType("int");

                    b.Property<int>("tabItemDocumentocodigoItemDocumento")
                        .HasColumnType("int");

                    b.Property<int>("tabObjetocodigoBancoDados")
                        .HasColumnType("int");

                    b.Property<int>("tabObjetocodigoObjeto")
                        .HasColumnType("int");

                    b.Property<string>("tabObjetoserverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento");

                    b.HasIndex("tabObjetoserverName", "tabObjetocodigoBancoDados", "tabObjetocodigoObjeto");

                    b.ToTable("tabItemDocumentoObjeto");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumentoPermissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("tabItemDocumentocodigoDocumento")
                        .HasColumnType("int");

                    b.Property<int>("tabItemDocumentocodigoItemDocumento")
                        .HasColumnType("int");

                    b.Property<int>("tabPermissaocodigoPermissao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tabPermissaocodigoPermissao");

                    b.HasIndex("tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento");

                    b.ToTable("tabItemDocumentoPermissao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabObjeto", b =>
                {
                    b.Property<string>("serverName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("codigoBancoDados")
                        .HasColumnType("int");

                    b.Property<int>("codigoObjeto")
                        .HasColumnType("int");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdObjeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdObjeto"));

                    b.Property<string>("ObjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TabItemDocumentocodigoDocumento")
                        .HasColumnType("int");

                    b.Property<int?>("TabItemDocumentocodigoItemDocumento")
                        .HasColumnType("int");

                    b.Property<int>("codigoSchema")
                        .HasColumnType("int");

                    b.Property<string>("descricaoTipoObjeto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serverName", "codigoBancoDados", "codigoObjeto");

                    b.HasIndex("TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento");

                    b.ToTable("tabObjeto");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabPermissao", b =>
                {
                    b.Property<int>("codigoPermissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoPermissao"));

                    b.Property<string>("classePermissao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricaoPermissao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codigoPermissao");

                    b.ToTable("tabPermissao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabUsuario", b =>
                {
                    b.Property<int>("codigoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoUsuario"));

                    b.Property<string>("loginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codigoUsuario");

                    b.ToTable("tabUsuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabAvaliacao", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabItemDocumento", null)
                        .WithMany("avaliacao")
                        .HasForeignKey("TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabAvaliador", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabUsuario", "tabUsuario")
                        .WithOne("tabAvaliador")
                        .HasForeignKey("DataStoreWebAPI.Entities.TabAvaliador", "codigoAvaliador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabUsuario");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabCliente", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabUsuario", "tabUsuario")
                        .WithOne("tabCliente")
                        .HasForeignKey("DataStoreWebAPI.Entities.TabCliente", "codigoCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabUsuario");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabDocumento", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "avaliador")
                        .WithMany()
                        .HasForeignKey("avaliadorId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId");

                    b.Navigation("avaliador");

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumento", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabDocumento", null)
                        .WithMany("tabItemDocumento")
                        .HasForeignKey("codigoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumentoObjeto", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabItemDocumento", "tabItemDocumento")
                        .WithMany()
                        .HasForeignKey("tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataStoreWebAPI.Entities.TabObjeto", "tabObjeto")
                        .WithMany()
                        .HasForeignKey("tabObjetoserverName", "tabObjetocodigoBancoDados", "tabObjetocodigoObjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabItemDocumento");

                    b.Navigation("tabObjeto");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumentoPermissao", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabPermissao", "tabPermissao")
                        .WithMany("tabItemDocumentoPermissao")
                        .HasForeignKey("tabPermissaocodigoPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataStoreWebAPI.Entities.TabItemDocumento", "tabItemDocumento")
                        .WithMany("permissao")
                        .HasForeignKey("tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabItemDocumento");

                    b.Navigation("tabPermissao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabObjeto", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabItemDocumento", null)
                        .WithMany("objeto")
                        .HasForeignKey("TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabDocumento", b =>
                {
                    b.Navigation("tabItemDocumento");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumento", b =>
                {
                    b.Navigation("avaliacao");

                    b.Navigation("objeto");

                    b.Navigation("permissao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabPermissao", b =>
                {
                    b.Navigation("tabItemDocumentoPermissao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabUsuario", b =>
                {
                    b.Navigation("tabAvaliador");

                    b.Navigation("tabCliente");
                });
#pragma warning restore 612, 618
        }
    }
}

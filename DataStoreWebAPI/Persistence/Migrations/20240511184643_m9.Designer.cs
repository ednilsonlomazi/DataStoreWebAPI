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
    [Migration("20240511184643_m9")]
    partial class m9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabAvaliacao", b =>
                {
                    b.Property<int>("codigoAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoAvaliacao"));

                    b.Property<DateTime>("dtaAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("emissorcodigoEmissor")
                        .HasColumnType("int");

                    b.Property<string>("justificativa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("resultado")
                        .HasColumnType("bit");

                    b.HasKey("codigoAvaliacao");

                    b.HasIndex("emissorcodigoEmissor");

                    b.ToTable("TabAvaliacao");
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

                    b.Property<int>("clientecodigoCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("emissorcodigoEmissor")
                        .HasColumnType("int");

                    b.Property<bool>("isCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("isOpen")
                        .HasColumnType("bit");

                    b.HasKey("codigoDocumento");

                    b.HasIndex("clientecodigoCliente");

                    b.HasIndex("emissorcodigoEmissor");

                    b.ToTable("tabDocumento");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabEmissor", b =>
                {
                    b.Property<int>("codigoEmissor")
                        .HasColumnType("int");

                    b.HasKey("codigoEmissor");

                    b.ToTable("tabEmissors");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumento", b =>
                {
                    b.Property<int>("codigoDocumento")
                        .HasColumnType("int");

                    b.Property<int>("codigoItemDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codigoItemDocumento"));

                    b.Property<int?>("avaliacaocodigoAvaliacao")
                        .HasColumnType("int");

                    b.Property<int>("objetocodigoBancoDados")
                        .HasColumnType("int");

                    b.Property<int>("objetocodigoObjeto")
                        .HasColumnType("int");

                    b.Property<string>("objetoserverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("permissaocodigoPermissao")
                        .HasColumnType("int");

                    b.HasKey("codigoDocumento", "codigoItemDocumento");

                    b.HasIndex("avaliacaocodigoAvaliacao");

                    b.HasIndex("permissaocodigoPermissao");

                    b.HasIndex("objetoserverName", "objetocodigoBancoDados", "objetocodigoObjeto");

                    b.ToTable("tabItemDocumento");
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

                    b.Property<int>("codigoSchema")
                        .HasColumnType("int");

                    b.Property<string>("descricaoTipoObjeto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("serverName", "codigoBancoDados", "codigoObjeto");

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

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabAvaliacao", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabEmissor", "emissor")
                        .WithMany()
                        .HasForeignKey("emissorcodigoEmissor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("emissor");
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
                    b.HasOne("DataStoreWebAPI.Entities.TabCliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clientecodigoCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataStoreWebAPI.Entities.TabEmissor", "emissor")
                        .WithMany()
                        .HasForeignKey("emissorcodigoEmissor");

                    b.Navigation("cliente");

                    b.Navigation("emissor");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabEmissor", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabUsuario", "tabUsuario")
                        .WithOne("tabEmissor")
                        .HasForeignKey("DataStoreWebAPI.Entities.TabEmissor", "codigoEmissor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tabUsuario");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabItemDocumento", b =>
                {
                    b.HasOne("DataStoreWebAPI.Entities.TabAvaliacao", "avaliacao")
                        .WithMany()
                        .HasForeignKey("avaliacaocodigoAvaliacao");

                    b.HasOne("DataStoreWebAPI.Entities.TabDocumento", null)
                        .WithMany("tabItemDocumento")
                        .HasForeignKey("codigoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataStoreWebAPI.Entities.TabPermissao", "permissao")
                        .WithMany()
                        .HasForeignKey("permissaocodigoPermissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataStoreWebAPI.Entities.TabObjeto", "objeto")
                        .WithMany()
                        .HasForeignKey("objetoserverName", "objetocodigoBancoDados", "objetocodigoObjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("avaliacao");

                    b.Navigation("objeto");

                    b.Navigation("permissao");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabDocumento", b =>
                {
                    b.Navigation("tabItemDocumento");
                });

            modelBuilder.Entity("DataStoreWebAPI.Entities.TabUsuario", b =>
                {
                    b.Navigation("tabCliente");

                    b.Navigation("tabEmissor");
                });
#pragma warning restore 612, 618
        }
    }
}

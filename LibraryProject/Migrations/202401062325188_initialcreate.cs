namespace LibraryProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adherents",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                    Prenom = c.String(),
                    Adresse = c.String(),
                    Email = c.String(),
                    Phone = c.String(),
                    Image = c.String(),
                    DateNaissance = c.DateTime(nullable: false),
                    Password = c.String(),
                    Login = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Admins",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Login = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Auteurs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                    Prenom = c.String(),
                    Image = c.String(),
                    DateNaissance = c.DateTime(nullable: false),
                    DateDeces = c.DateTime(nullable: true),
                    Biographie = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                    Prenom = c.String(),
                    Status = c.Int(nullable: false),
                    Adresse = c.String(),
                    Email = c.String(),
                    Phone = c.String(),
                    Image = c.String(),
                    DateNaissance = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Emprunts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LivreId = c.Int(nullable: false),
                    AdherentId = c.Int(nullable: false),
                    Montant = c.Single(nullable: false),
                    Date_empr = c.DateTime(nullable: false),
                    Date_retour = c.DateTime(nullable: false),
                    EtatRetour = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adherents", t => t.AdherentId, cascadeDelete: true)
                .ForeignKey("dbo.Livres", t => t.LivreId, cascadeDelete: true)
                .Index(t => t.LivreId)
                .Index(t => t.AdherentId);

            CreateTable(
                "dbo.Livres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Titre = c.String(),
                    DateParution = c.DateTime(nullable: false),
                    Description = c.String(),
                    NbrExempl = c.Int(nullable: false),
                    NbrEmpr = c.Int(nullable: false),
                    Image = c.String(),
                    Prix = c.Single(nullable: false),
                    AuteurId = c.Int(nullable: false),
                    Genre = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auteurs", t => t.AuteurId, cascadeDelete: true)
                .Index(t => t.AuteurId);

            CreateTable(
                "dbo.Panier",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LivreId = c.Int(nullable: false),
                    AdherentId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adherents", t => t.AdherentId, cascadeDelete: true)
                .ForeignKey("dbo.Livres", t => t.LivreId, cascadeDelete: true)
                .Index(t => t.LivreId)
                .Index(t => t.AdherentId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Panier", "LivreId", "dbo.Livres");
            DropForeignKey("dbo.Panier", "AdherentId", "dbo.Adherents");
            DropForeignKey("dbo.Emprunts", "LivreId", "dbo.Livres");
            DropForeignKey("dbo.Livres", "AuteurId", "dbo.Auteurs");
            DropForeignKey("dbo.Emprunts", "AdherentId", "dbo.Adherents");
            DropIndex("dbo.Panier", new[] { "AdherentId" });
            DropIndex("dbo.Panier", new[] { "LivreId" });
            DropIndex("dbo.Livres", new[] { "AuteurId" });
            DropIndex("dbo.Emprunts", new[] { "AdherentId" });
            DropIndex("dbo.Emprunts", new[] { "LivreId" });
            DropTable("dbo.Panier");
            DropTable("dbo.Livres");
            DropTable("dbo.Emprunts");
            DropTable("dbo.Employees");
            DropTable("dbo.Auteurs");
            DropTable("dbo.Admins");
            DropTable("dbo.Adherents");
        }
    }
}

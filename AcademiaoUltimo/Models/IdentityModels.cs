﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AcademiaoUltimo.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que a authenticationType deve corresponder a uma definida em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações do usuário personalizadas aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AcademiaoUltimo.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<AcademiaoUltimo.Models.Plano> Planoes { get; set; }

        public System.Data.Entity.DbSet<AcademiaoUltimo.Models.Pagamento> Pagamentoes { get; set; }

        public System.Data.Entity.DbSet<AcademiaoUltimo.Models.Treino> Treinoes { get; set; }

        public System.Data.Entity.DbSet<AcademiaoUltimo.Models.Instrutor> Instrutors { get; set; }

        public System.Data.Entity.DbSet<AcademiaoUltimo.Models.Aula> Aulas { get; set; }
    }
}
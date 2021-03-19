using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Project4.Models;

[assembly: OwinStartupAttribute(typeof(Project4.Startup))]
namespace Project4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
            //Chạy 1 lần rồi tắt hoặc xóa đi không ai quan tâm đâu
            //addAccountToQuanNgucTruongRole();

        }

        private void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            if (!roleManager.RoleExists("QuanNgucTruong"))
            {  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "QuanNgucTruong";
                roleManager.Create(role);
                
            }   

            if (!roleManager.RoleExists("QuanNguc"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "QuanNguc";
                roleManager.Create(role);

            }
   
        }

        //Thêm tài khoản đang có vào Role QuanNgucTruong
        private void addAccountToQuanNgucTruongRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("d138ccc2-2421-4438-bedb-da1631774286", "QuanNgucTruong"); //Đổi id thành tài khoản có sẵn
        }
    }
}

using CustomerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace CustomerService.Infrastructure
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModel : RuntimeModel
    {
        private static MainDbContextModel? _instance;
        public static IModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainDbContextModel();
                    _instance.Initialize();
                    _instance.Customize();
                }

                return _instance;
            }
        }

        partial void Initialize();

        partial void Customize();
    }
}

  
   
   
   
 
		   


   

   
	
using Skahal.Generators.Samples.Domain;
using Skahal.Generators.Samples.Domain.Specifications;
   

using System;
using Skahal.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Repositories;
using Skahal.Generators.Samples.Domain;

	  
 
      
namespace Skahal.Generators.Samples.Repositories.MongoDB 
{   
	/// <summary> 
	/// MongoDB Company repository.   
	/// </summary>
	public class MongoDBCompanyRepository : MongoDBRepositoryBase<Company>,  ICompanyRepository
	{
		#region Constructors 
		/// <summary>  
		/// Initializes a new instance of the
		/// <see cref="Skahal.Generators.Samples.Repositories.MongoDB.MongoDBCompanyRepository"/> class.
		/// </summary>
		public MongoDBCompanyRepository() : base(System.Configuration.ConfigurationManager.AppSettings.Get("(MONGOHQ_URL|MONGOLAB_URI)"), "Companies")
		{
		}
		#endregion
	}
}
 
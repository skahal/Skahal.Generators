  
   
   
   
 
		   


   

   
	
using Skahal.Generators.Samples.Domain;
using Skahal.Generators.Samples.Domain.Specifications;
   

using System;
using Skahal.Infrastructure.Framework.Repositories;
using Skahal.Generators.Samples.Domain;
 
	  
 
      
namespace Skahal.Generators.Samples.Repositories.Memory  
{    
	/// <summary>  
	/// Testing Company repository.   
	/// </summary>  
	public class MemoryCompanyRepository : MemoryRepository<Company>, ICompanyRepository
	{
		#region Fields 
		private static long s_lastKey; 
		private static object s_lock = new Object(); 
		#endregion
		
		#region Constructors 
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="Skahal.Generators.Samples.Repositories.Memory.MemoryCompanyRepository"/> class.
		/// </summary>
		public MemoryCompanyRepository() : base((g) => { lock(s_lock) { return ++s_lastKey; } })
		{
			s_lastKey = 0;
		}
		#endregion
	}
}
 
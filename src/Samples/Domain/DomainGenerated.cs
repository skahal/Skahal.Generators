  
   
   
   
 
		   


   

   
  
#region Usings    
using System;  
using System.Collections.Generic;    
using System.IO;            
using System.Linq;     
using Skahal.Infrastructure.Framework.Commons;  
using Skahal.Infrastructure.Framework.Domain; 
using Skahal.Infrastructure.Framework.Repositories;   
using HelperSharp;       
using KissSpecifications;  
#endregion             
          
       
namespace Skahal.Generators.Samples.Domain 
{   
	public partial interface ICompanyRepository : IRepository<Company>
	{
		}   
	  
	// <summary>
	/// Domain layer company service.
	/// </summary>
	public partial class CompanyService : ServiceBase<Company, ICompanyRepository, IUnitOfWork>
	{ 
		#region Constructors 
      	/// <summary>  
		/// Initializes a new instance of the <see cref="Skahal.Generators.Samples.Domain.Companies.CompanyService"/> class.
		/// </summary>
		public  CompanyService()  
		{
		} 

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Generators.Samples.Domain.Companies.CompanyService"/> class.
		/// </summary>
		/// <param name="companyRepository"> Company repository.</param>    
		/// <param name="unitOfWork">Unit of work.</param> 
		public  CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
		: base(companyRepository, unitOfWork)
		{
		} 
        #endregion
		
		#region Methods 
		
		/// <summary>
		/// Gets the company by key.
		/// </summary>
		/// <returns>The company.</returns>
		/// <param name="key">The key.</param>  
		public Company GetCompanyByKey(object key)
		{
			return MainRepository.FindBy (key);
		}
		
				
		/// <summary>
		/// Gets all Companies. 
		/// </summary>
		/// <returns>The all Companies.</returns>
		public IList<Company> GetAllCompanies()
		{
			return MainRepository.FindAll(g => true).ToList();
		}
		
		/// <summary>
		/// Counts all Companies.
		/// </summary>
		public long CountAllCompanies() 
		{ 
			return MainRepository.CountAll (g => true); 
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		partial void ExecuteSaveSpecification(Company company);
		
		/// <summary>
		/// Saves the company.
		/// </summary>
		/// <param name="company">The company.</param>
		public void SaveCompany(Company company)
		{
			ExceptionHelper.ThrowIfNull ("company", company);

			ExecuteSaveSpecification (company);
			
			MainRepository [company.Key] = company;
			UnitOfWork.Commit (); 
		} 

		/// <summary> 
		/// Executes the delete specification.
		/// </summary>  
		partial void ExecuteDeleteSpecification(object companyKey, Company company);
		  
		/// <summary>  
		/// Deletes the company.
		/// </summary> 
		/// <param name="key">The key.</param> 
		public void DeleteCompany (object key)
		{ 
			var company = GetCompanyByKey (key);
			
			if(company == null)
			{
				throw new ArgumentException("Company with key '{0}' does not exists.".With(key));
			}
			
			ExecuteDeleteSpecification (key, company);

			MainRepository.Remove (company); 
			UnitOfWork.Commit ();
		}
		#endregion
	}
}


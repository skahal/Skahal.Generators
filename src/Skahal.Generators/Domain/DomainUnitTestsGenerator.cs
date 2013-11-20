  
   
   
   
 
		   


   

   
	
using Skahal.Generators.Samples.Domain;
using Skahal.Generators.Samples.Domain.Specifications;
   
  
#region Usings    
using System;
using NUnit.Framework;  
using TestSharp;  
using Skahal.Infrastructure.Framework.Repositories;  
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Generators.Samples.Repositories.Memory; 
#endregion      
   
namespace Skahal.Generators.Samples.Domain.UnitTests  
{ 
	public static class Stubs  
	{
		#region Properties
		public static IUnitOfWork UnitOfWork { get; set; }
 
 
		public static ICompanyRepository CompanyRepository { get; set; } 
		 
		#endregion 

		#region Methods
		public static void Initialize ()
		{
			DependencyService.Register<IUnitOfWork> (UnitOfWork = new MemoryUnitOfWork());
 
			DependencyService.Register<ICompanyRepository> (CompanyRepository = new MemoryCompanyRepository());
			CompanyRepository.SetUnitOfWork (UnitOfWork);
	
		}
		#endregion
	}
}

         
     

	 
namespace Skahal.Generators.Samples.Domain.UnitTests
{
	[TestFixture()]
	public partial class CompanyServiceTest
	{
		#region Fields
		private CompanyService m_target; 
		#endregion
  
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company() { Key = 1 } );
			Stubs.CompanyRepository.Add (new Company() { Key = 2 } );
			Stubs.CompanyRepository.Add (new Company() { Key = 3 } );
			Stubs.CompanyRepository.Add (new Company() { Key = 4 } );
			Stubs.UnitOfWork.Commit ();

			m_target = new CompanyService ();

		}
		#endregion

		#region Tests
		[Test]
		public void CountAllCompanies_NoArguments_AllCompaniesCounted()
		{
			var actual = m_target.CountAllCompanies ();
			Assert.AreEqual (4, actual);
		}

		[Test]
		public void DeleteCompany_CompanyNotExistis_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentException("Company with key '0' does not exists."), () => {
				m_target.DeleteCompany(0);
			});
		}
   
		[Test]
		public void DeleteCompany_CompanyExistis_Exception()
		{
			Assert.AreEqual (4, m_target.CountAllCompanies ());

			m_target.DeleteCompany(1);
			Assert.AreEqual (3, m_target.CountAllCompanies ());

			m_target.DeleteCompany(2);
			Assert.AreEqual (2, m_target.CountAllCompanies ());

			m_target.DeleteCompany(3);
			Assert.AreEqual (1, m_target.CountAllCompanies ());

			m_target.DeleteCompany(4);
			Assert.AreEqual (0, m_target.CountAllCompanies ());
		}

		[Test]
		public void GetAllCompanies_NoArgs_AllCompanies ()
		{
			var actual = m_target.GetAllCompanies();
			Assert.AreEqual (4, actual.Count);
		}

		[Test]
		public void GetCompanyByKey_KeyCompanyDoesNotExists_Null ()
		{
			var actual = m_target.GetCompanyByKey (0);
			Assert.IsNull (actual);
		}

		[Test]
		public void GetCompanyByKey_KeyCompanyExists_Company ()
		{
			var actual = m_target.GetCompanyByKey (2);
			Assert.AreEqual (2, actual.Key);

			actual = m_target.GetCompanyByKey (3);
			Assert.AreEqual (3, actual.Key);
		}	
	 
		[Test]
		public void SaveCompany_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("company"), () => {
				m_target.SaveCompany (null);
			});
		}
 
		[Test]  
		public void SaveCompany_CompanyDoesNotExists_Created()
		{
			var company = new Company () { Key = 5 };
 
			m_target.SaveCompany (company);

			Assert.AreEqual(5, m_target.CountAllCompanies());
			Assert.AreEqual (5, m_target.GetCompanyByKey (company.Key).Key);
		}
 
		[Test]
		public void SaveCompany_CompanyDoesExists_Updated()
		{
			var company = new Company () { 
				Key = 1 
			};

			m_target.SaveCompany (company);

			Assert.AreEqual(4, m_target.CountAllCompanies());
			Assert.AreEqual (1, m_target.GetCompanyByKey (company.Key).Key);
		}
 
		#endregion
	}
}



	

  
   
   
   
 
		   


   

   
	
using Skahal.Generators.Samples.Domain;
using Skahal.Generators.Samples.Domain.Specifications;
   
  
#region Usings    
using System; 
using NUnit.Framework;  
using TestSharp; 
using Skahal.Infrastructure.Framework.Repositories; 
using Skahal.Infrastructure.Framework.Commons; 
#endregion      
         
        

namespace Skahal.Generators.Samples.Domain.UnitTests
{ 
	[TestFixture()] 
	public partial class CompanyExistsSpecificationTest
	{
	 
		#region Tests 
		[Test] 
		public void IsSatisfiedBy_NullCompany_False()
		{
			var target = new CompanyExistsSpecification();
			
			Assert.IsFalse(target.IsSatisfiedBy(null));
		} 
		
		[Test] 
		public void IsSatisfiedBy_NonExistsCompany_False()
		{
			var target = new CompanyExistsSpecification(); 
			
			Assert.IsFalse(target.IsSatisfiedBy(new Company()));
		}
		
		[Test]
		public void IsSatisfiedBy_ExistsCompany_True()
		{
			Stubs.Initialize ();
			Stubs.CompanyRepository.Add (new Company() { Key = 1 });
			Stubs.UnitOfWork.Commit ();
			 
			var target = new CompanyExistsSpecification();
			
			Assert.IsTrue(target.IsSatisfiedBy(new Company() { Key = 1 }));
		}
		#endregion
	}
	}



	

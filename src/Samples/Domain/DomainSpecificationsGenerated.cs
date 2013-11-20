  
   
   
   
 
		   


   

   
  
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
            
     
namespace Skahal.Generators.Samples.Domain.Specifications
{   
	/// <summary>   
	/// Company exists specification.  
	/// </summary>
	public class CompanyExistsSpecification : SpecificationBase<Company>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Company target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Company can't be null.";
				return false;
			}
			else if(new CompanyService().GetCompanyByKey(target.Key) == null)
			{
				NotSatisfiedReason = "Company with key '{0}' does not exists.".With (target.Key);
				return false;
			}
			
			return true;
		}

		#endregion
	}
	 
	}


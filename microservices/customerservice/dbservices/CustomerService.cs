
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using signupservice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace signupservice.dbservices{
public class CustomerService
    {
        private readonly DynamoDBContext _dynamoDBContext;

        public CustomerService(DynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }
        public async Task SaveAsync(CustomerDetails customerDetails){
            await _dynamoDBContext.SaveAsync(customerDetails);
        }
    }
}
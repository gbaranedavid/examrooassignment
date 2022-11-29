using Microsoft.AspNetCore.Mvc;
using signupservice.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using signupservice.Models;
using signupservice.dbservices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace signupservice.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerDetailsController : ControllerBase
{
    private readonly ILogger<CustomerDetailsController> _logger;

    public CustomerDetailsController(ILogger<CustomerDetailsController> logger){
        _logger = logger;
    }
    [HttpGet(Name = "GetAllCustomerDetails")]
    public async Task<IActionResult> Get()
    {
        
            Console.WriteLine("Get API was called");
            AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            clientConfig.ServiceURL = "http://localhost:8000";
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);
            DynamoDBContext currentDBContext = new DynamoDBContext(client);
            var customerList = await currentDBContext.ScanAsync<CustomerDetails>(default).GetRemainingAsync();
            
        return Ok(customerList);
    }
    [HttpPost (Name = "PostCustomerDetails")]
    public async Task<IActionResult> Post(CustomerDetails customerDetails)
    {
        if(customerDetails.customerEmail !=null && customerDetails.customerEmail !=null
        && customerDetails.customerFirstName !=null && customerDetails.customerPassword !=null){
            Console.WriteLine("Post API was called");
            AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            clientConfig.ServiceURL = "http://localhost:8000";
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);
            DynamoDBContext currentDBContext = new DynamoDBContext(client);
            CustomerService customerServiceObject = new CustomerService(currentDBContext);
            customerServiceObject.SaveAsync(customerDetails).Wait();
            
            return Ok("{'customerSignupStatus':'successful'}");
        }else{
            return NotFound();
        }
    }
    [HttpPut("login")]
    public async Task<IActionResult> LoginCustomer(CustomerDetails customerDetails)
    {
        
        Console.WriteLine("login API was called");
        AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
        clientConfig.ServiceURL = "http://localhost:8000";
        AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);
        DynamoDBContext currentDBContext = new DynamoDBContext(client);
        Console.WriteLine("Email found is: "+customerDetails.customerEmail);
        Console.WriteLine("Password found is: "+customerDetails.customerPassword);
        var customer = await currentDBContext.LoadAsync<CustomerDetails>(customerDetails.customerEmail,customerDetails.customerPassword);
        
        CustomerDetails emptyCustomerObject = new CustomerDetails();
        if (customer == null){
             return NotFound();
        }else{
            if(customerDetails.customerEmail==customer.customerEmail 
            && customerDetails.customerPassword==customer.customerPassword ){
                Console.WriteLine("Login successful");
                return Ok(customer);
            }else{
                Console.WriteLine("Login unsuccessful");
                return Ok(emptyCustomerObject);
            }
            
        }
    }
    
}

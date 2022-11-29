using Amazon.DynamoDBv2.DataModel;
namespace signupservice.Models{

[DynamoDBTable("CustomerRecords")]
public class CustomerDetails{

    [DynamoDBHashKey]
    public string customerEmail{get; set;}
    [DynamoDBRangeKey]
    public string customerPassword{get; set;}
    public string customerFirstName{get; set;}
    public string customerLastName{get; set;}
    public string customerMiddleName{get; set;}
    public string customerGender{get; set;}
    public string customerCountryOfOrigin{get; set;}
    public string customerOtherInfo{get; set;}
    public String customerMobileNo{get; set;}

    /*
    *{
    "TableName": "CustomerRecords",
    "KeySchema": [
      { "AttributeName": "customerEmail", "KeyType": "HASH" },
      { "AttributeName": "customerPassword", "KeyType": "RANGE" }
    ],
    "AttributeDefinitions": [
      { "AttributeName": "customerEmail", "AttributeType": "S"},
      { "AttributeName": "customerPassword", "AttributeType": "S" }
    ],
    "ProvisionedThroughput": {
      "ReadCapacityUnits": 5,
      "WriteCapacityUnits": 5
    }
}


    **/
}
}
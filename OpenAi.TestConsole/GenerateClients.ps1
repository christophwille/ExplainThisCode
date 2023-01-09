# https://github.com/RicoSuter/NSwag/wiki/NSwagStudio

dotnet tool restore

$openapidef = './ApiClients/openapi.yaml'
$apiName = 'OpenAI'
$apiNamespace = 'OpenAI.ApiClients'
$clientFileName = "./ApiClients/${apiName}.Generated.cs"

dotnet nswag openapi2csclient `
	"/Input:${openapidef}" `
	"/Output:${clientFileName}" `
	"/Namespace:${apiNamespace}" `
	"/ClassName:${apiName}ApiClient" `
	"/GenerateClientInterfaces:true" `
	"/UseHttpClientCreationMethod:false" `
	"/InjectHttpClient:true" `
	"/UseBaseUrl:true" `
	"/UseHttpRequestMessageCreationMethod:true" `
	"/DateType:System.DateTimeOffset" `
	"/DateTimeType:System.DateTimeOffset" `
	"/GenerateOptionalParameters:true" `
	"/GenerateJsonMethods:true" `
	"/OperationGenerationMode:MultipleClientsFromOperationId" `
	"/ExceptionClass:${apiName}ApiException" `
	"/GenerateExceptionClasses:true"
 
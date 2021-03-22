# Weir.Synertrex.Erps.Api
Related to task SE-1414 As a user, I should be able to view the change history of Equipment Device Twin in the Web Portal

1. Gets all records https://weirerpsapi.azurewebsites.net/api/GetDeviceTwinData or search by physicalIdentifier 	  https://weirerpsapi.azurewebsites.net/api/GetDeviceTwinData?physicalIdentifier=cpl_s001_fg001

2. Authentication is set to level function. The key is set on Azure portal GetDeviceTwinData function function key (section).

3. Database connectionString is retrived from configuration section in Azure portal Function App.
 

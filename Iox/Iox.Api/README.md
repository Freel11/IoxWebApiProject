# API Endpoints

## POST 
1. /api/createuser - { "idnumber": ***Long***, "firstname": ***string***, "lastname": ***string***, "email": ***string***, "password": ***string*** }

**This will return the created user and account, initialised with 0 as its balance - take note of the accout id (first user created will have an account id of 1, the second with 2, etc.)**

2. /api/addvehicle - { "vin": ***string***, "licensenumber": ***string***, "registrationplate": ***string***, "licenseexpiry" ***dateTime*** (yyyy-mm-dd), "model": ***string***, "color": ***string***, "accountforeignkey": ***long*** (the acccoundid) }

**This will return the created vehicle and the account to which it belongs - If no License expiry date is given, it defaults to today**

## PUT

1. /api/deposit - { "id": ***long*** (the account id), balance: **decimal** (the ammount you want to add to the account) }

**This will return the account with the balance updated**

2. /ap/renewlicense - { "vin": ***string***, "accountid": ***long*** }

**This will return the vehicle with the licenseexiry field updated and the associated account's balance deducted - the price to renew the license has been set to 100, if the user doesn't have enough funds an exception is thrown saying 'insufficient funds'**

## GET

1 /api/getvehiclelist 

**This uses the query string in the url to filter through all the vehicles and returns the matching results. can take any of the vehcile attributes to filter. By default, will return 3 items per page. to move between different pages add 'pageNo={int}' to the query string. To update the number of results per page add 'pageSize={int}' to the query string**
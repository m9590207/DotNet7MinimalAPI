# Super Hero API

* .Net7 Minimal Api
* Entity Framework Core 
* SQL Server
* clean architecture 
* repository pattern
* CQRS MediatR
  
## API  
### �d��Super Hero by ID
**GET /api/SuperHero/{id}**
* Path params
  * id (int)

### ��sSuper Hero by ID
**PUT /api/SuperHero/{id}**
* Headers
  * Content-Type: application/json
* Path params
  * id (int) 
* Body params
  * name (string)
  * place (string)

### �R��Super Hero by ID
**DELETE /api/SuperHero/{id}**
* Path params
  * id (int)
  
### �s�WSuper Hero 
**POST /api/SuperHero**
* Headers
  * Content-Type: application/json
* Body params
  * name (string)
  * place (string)

### �d�ߩҦ�Super Hero
**GET /api/SuperHero**




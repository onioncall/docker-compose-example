# NOTICE
---

Generally speaking, you would handle this by creating a contracts project outside the scope of each service that defines your models, 
and what each api expects for requests/responses, and publish it as a nuget package.

That said, I'm not going to publish a nuget package for this tech talk. Sorry. We'll have to live with me doing this the inconvenient way, 
which involves defining the requests/responses/dtos that are needed in every service. 


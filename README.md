# MarkCollab Editor

* @Author: TimsManter
* @AuthorSite: [TimsManter.NET](http://timsmanter.net/)
* @CreateDate: 2017-06
* @Editor: Visual Studio Code
* @Language: C#
* @Framework: .NET Core | ASP.NET Core | Entity Framework Core
* @Locale: en_US
* @License: n/a yet
* @Status: Dev | Active

## Overview

MarkCollab is a simple collaboration tool for creating various types of documents using Markdown syntax. The main idea is to create a self-hosted Web Application that contains everything to create Markdown documents by many people in the same time.

## API Reference

### Get all documents
```http
GET {root}/api/docs
```

### Get single document of {id}
```http
GET {root}/api/docs/{id}
```

### Create new document with {title}
```http
POST {root}/api/docs/{title}
```

### Update document content
```http
PATCH {root}/api/docs/{id}/content
```
> Note: Remember to add `Content-Type: text/plain` header.

### Update document title
```http
PATCH {root}/api/docs/{id}/title
```
> Note: Remember to add `Content-Type: text/plain` header.

### Delete document of {id}
```http
DELETE {root}/api/docs/{id}
```
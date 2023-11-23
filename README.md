# OpenGTINDBHandler
C# Library for opengtindb.org

# Features
- Request product information (from GTIN/EAN) from opengtindb.org 

# How to Use

```c#
string user_id = "USER_ID";
OpenGTINDBHandler openGTINDBHandler = new(user_id);

string gtin = "GTIN"
string product_information = openGTINDBHandler.getProductInformation(gtin);
```

returns plain-text in following structure:
```
error=0
---
name=Natürliches Mineralwasser
detailname=Bad Vilbeler RIED Quelle
vendor=H. Kroner GmbH & CO. KG
maincat=Getränke, Alkohol
subcat=
contents=19
pack=1
descr=Natürliches Mineralwasser mit Kohlensäure versetzt
origin=Deutschland
validated=25 %
---
```

**more information can be found on: http://opengtindb.org/api.php**
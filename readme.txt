примеры запросов WcfEndpoint

В формате xml

POST http://localhost:16609/Service.svc/addproduct

User-Agent: Fiddler
Content-Type: application/json
Host: localhost:16609
Content-Length: 131

{"body":"%3CProduct%3E%3Cproduct_name%3ETable%3C%2Fproduct_name%3E%3Cproduct_price%3E124.20%3C%2Fproduct_price%3E%3C%2FProduct%3E"}

JSON

{"body"="%7B%22product_name%22%3A%22Magic+ball%22%2C%22product_price%22%3A3.32%7D"}

WebApiEndpoint

JSON

POST http://localhost:1846/product

User-Agent: Fiddler
Content-Type: application/json
Host: localhost:1846
Content-Length: 50

{"product_name":"Magic ball","product_price":3.32}

XML
User-Agent: Fiddler
Content-Type: application/xml
Host: localhost:1846
Content-Length: 88

<Product><product_name>Apple</product_name><product_price>1.08</product_price></Product>
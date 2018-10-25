 Decoding a JWT to read the information inside 
## What is JWT?
JSON Web Token (JWT) is an open standard ([RFC 7519](https://tools.ietf.org/html/rfc7519)) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object. This information can be verified and trusted because it is digitally signed. JWTs can be signed using a secret (with the **HMAC** algorithm) or a public/private key pair using **RSA** or **ECDSA**.

***Signed tokens can verify the _integrity_ of the claims contained within it, while encrypted tokens _hide_ those claims from other parties. When tokens are signed using public/private key pairs, the signature also certifies that only the party holding the private key is the one that signed it.***

##  JSON Web Token structure?

JSON Web Tokens consist of three parts separated by dots (`.`), which are:

-   Header
-   Payload
-   Signature

typically looks like the following.

`xxxxx.yyyyy.zzzzz`

### Header

The header  _typically_  consists of two parts: the type of the token, which is JWT, and the hashing algorithm being used, such as HMAC SHA256 or RSA. In my project I use HMAC SHA 512.

For example:
```
{
  "alg": "HS256",
  "typ": "JWT"
}
```
### Payload

The second part of the token is the payload, which contains the claims. Claims are statements about an entity (typically, the user information such as userRole and etc.)  There are three types of claims:  _registered_,  _public_, and  _private_  claims.

-   [**Registered claims**](https://tools.ietf.org/html/rfc7519#section-4.1): These are a set of predefined claims which are not mandatory but recommended, to provide a set of useful, interoperable claims. Some of them are:  **iss**  (issuer),  **exp**  (expiration time),  **sub**  (subject),  **aud**(audience), and  [others](https://tools.ietf.org/html/rfc7519#section-4.1).
    
    > Notice that the claim names are only three characters long as JWT is meant to be compact.
    
-   [**Public claims**](https://tools.ietf.org/html/rfc7519#section-4.2): These can be defined at will by those using JWTs. But to avoid collisions they should be defined in the  [IANA JSON Web Token Registry](https://www.iana.org/assignments/jwt/jwt.xhtml)  or be defined as a URI that contains a collision resistant namespace.
    
-   [**Private claims**](https://tools.ietf.org/html/rfc7519#section-4.3): These are the custom claims created to share information between parties that agree on using them and are neither  _registered_  or  _public_claims.
  
```
{
  "sub": "1234567890",
  "name": "John Doe",
  "admin": true
}
```

### Signature
To create the signature part you have to take the encoded header, the encoded payload, a secret, the algorithm specified in the header, and sign that.

```
HMACSHA256(
  base64UrlEncode(header) + "." +
  base64UrlEncode(payload),
  secret)
```
## Sample C# Code to Decode a JWT token

sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout aspnetapp.key -out aspnetapp.crt -config aspnetapp.conf -passin pass:Admin:0000
sudo openssl pkcs12 -export -out aspnetapp.pfx -inkey aspnetapp.key -in aspnetapp.crt

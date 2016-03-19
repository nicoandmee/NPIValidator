# NPIValidator
A tool for validating NPI (National Provider Identifier) Numbers
\nWritten in C# 


Usage:
Run the exe, enter NPI as a ten-digit number (where last digit is the check-digit) without any prefix or special characters. 
Voila, your NPI will be validated - or not ;)



Background:

NPI Numbers are very useful in data analysis of healthcare providers and having a surefire way of telling whether an NPI is valid can be very useful for user input validation. 
NPI's can be verified to be valid using the Luhn Algorithm, the same algorithm used for a variety of such important things like Credit Card Numbers, IMEI's, some Social Security Numbers, etc. 


Further reading: https://en.wikipedia.org/wiki/Luhn_algorithm

REM Construction of the grammar-related files.
call goldbuilder HP67.grm HP67.cgt
call createskelprog HP67.cgt "C-Sharp - Calitha Interface Based.pgt" Parser.cs
call createskelprog HP67.cgt "C-Sharp - Calitha Interface Implementation.pgt" Template.cs
resxgen /i:HP67.cgt /o:Parser.resx /n:CGT
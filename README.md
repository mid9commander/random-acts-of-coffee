Randomly matches Namely employees and prompts them to get together for coffee and a chat

## MatchArranger
Top level logic with an entry point to arrange Random Acts of Coffee

## HrisApiConsumer
Consume HRIS API endpoint and deserialize its JSON into HrisApi POCOs

## ProfilesToEmployeeTransformer
Transform the HrisApi POCOs into Employee POCOs

## IMatchAlerter
Interface used to alert matches

## EmailMatchAlerter
Alerts matches via email

## IMatchLogger
Interface used to log matches and prevent matches from being duplicated

## SqlMatchLogger
Logs matches to the RandomActsOfCoffee.dbo.Matches table. Checks new matches against the same table to prevent duplicates.
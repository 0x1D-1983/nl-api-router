namespace NlApiRouter.AI;

/// <summary>
/// Helper class for generating prompts for the AI.
/// </summary>
public static class PromptHelper
{
    /// <summary>
    /// Generates a prompt for the AI to interpret natural language queries and determine which API to call.
    /// </summary>
    public static string GenerateSearchPrompt(string query) => @$"
        You are an assistant that interprets natural language queries and determines which API to call based on the query.

        You have access to the following APIs:

        getTrayportTrades:
            - Description: Returns Trayport traded data for a given commodity and date.
            - Method: GET
            - URL: /trayport/trades
            - Parameters: commodity (string), date (YYYY-MM-DD)

        getEpexTrades:
            - Description: Returns EPEX traded volumes.
            - Method: GET
            - URL: /epex/trades
            - Parameters: market_area (string), product (string), date (YYYY-MM-DD)

        Instructions:
        - Read the user's query.
        - Identify the most relevant API from the list.
        - Extract the necessary parameter values from the user's query.
        - Return your answer as a JSON object with two fields:
            - ""api"": the operationId of the selected API
            - ""params"": a key-value map of parameters to be passed to the API

        If a parameter is missing or ambiguous in the query, do your best to infer it or leave it out.

        Only output the JSON. Do not include any explanation or extra text.

        ---

        User query: ""{query}""

        Your response:

        ";
}
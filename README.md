# Natural Language API Router

This solution provides a natural language interface to query trade data from multiple providers (Epex and Trayport) using an AI-powered router.

## Components

### NlApiRouter
The main application that:
- Accepts natural language queries
- Uses Ollama (local LLM) to parse queries into structured API requests
- Routes requests to appropriate API handlers
- Returns consolidated trade data

### EpexApi
A sample API that provides trade data from the Epex provider:
- Exposes `/epex/trades` endpoint
- Returns mock trade data with Epex-specific formatting

### TrayportApi  
A sample API that provides trade data from the Trayport provider:
- Exposes `/trayport/trades` endpoint
- Returns mock trade data with Trayport-specific formatting

## Architecture

The solution follows a modular architecture:

1. **Query Parsing** - `OllamaService` uses a local Mistral model to parse natural language into structured `ApiQuery` objects
2. **Request Routing** - `ApiDispatcher` routes requests to appropriate handlers based on the parsed query
3. **API Handlers** - Individual handlers (`EpexTradesHandler`, `TrayportTradesHandler`) make calls to their respective APIs
4. **Data Providers** - Separate APIs serve mock trade data

## Example Usage

# Weather Application

The Weather Application is a comprehensive tool designed to deliver accurate and up-to-date weather forecasts. Utilizing the power of TomTom for fuzzy location retrieval and OpenWeatherMap for fetching weather forecasts, this application offers users a 5-day weather forecast based on their geographical location. Additionally, it leverages an OpenStack REST Server to archive past weather data, providing a unique feature that allows users to access historical weather forecasts.

## Features

- **Fuzzy Location Detection**: Leverages TomTom's API to accurately determine the user's latitude and longitude.
- **5-Day Weather Forecast**: Uses OpenWeatherMap to provide a detailed 5-day forecast, including high and low temperature, forecast, visibility, humidity, and the dates.
- **Weather History Access**: Designed to query an OpenStack REST Server for past weather data, enabling users to view historical weather forecasts (Note: this feature is not operational).

## Technologies Used

- **TomTom API**: For determining user location through latitude and longitude.
- **OpenWeatherMap API**: To fetch real-time weather data based on geographical coordinates.
- **OpenStack REST Server**: Intended for storing and retrieving historical weather data (Note: access to the server is currently unavailable, impacting this feature).

## Project Status

This project is currently in a semi-complete state. The core functionality, including fuzzy location detection and a 5-day weather forecast, is fully operational. However, the historical weather data feature is not functioning due to the lack of access to the necessary OpenStack REST Server.

## Getting Started

1. Clone the repository: https://github.com/Dattele/WeatherApplication.git
2. Open `landing.html` in your browser to view the application.

## Current Limitations

Please note that, due to current hosting and configuration limitations with our Ubuntu instance, the JavaScript code crucial for the application's functionality is not directly accessible for cloning or pulling.

# EvCharging API

The EV Charging API is a .NET 7 Web API project. The purpose of this project is to calculate the best electric vehicle (EV) charging periods based on user preferences and electricity rates. The API provides endpoints to interact with the scheduling algorithm and retrieve optimal charging periods for EV owners.

## Features

- Calculate optimal EV charging periods based on user preferences and electricity rates.
- Utilize SOLID principles for clean, maintainable, and extensible code.
- Utilize Swagger for API documentation and interactive API exploration.
- Containerize the application using Docker for Linux.

## Installation

1. Clone the repository:
_git clone https://github.com/arskrkmz/EVCharging.git_
2. Navigate to the project directory:
_cd ev-charging_

3. Build the Docker container:
_docker build -t ev-charging ._

## Usage

1. Run the Docker container:
_docker run -d -p 8080:80 ev-charging_

2. Open your web browser and navigate to the Swagger UI documentation:
_http://localhost:8080/swagger_

3. Use the Swagger UI to explore the available endpoints and their request/response models. You can test the API directly from the Swagger UI.


## Contributing

Contributions to the EV Charging Scheduler API are welcome! To contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them with clear commit messages.
4. Push your changes to your forked repository.
5. Submit a pull request to the main repository, explaining your changes and the problem they solve.


## License

The EV Charging Scheduler API is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute the code according to the terms of the license.



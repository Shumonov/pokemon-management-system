# PokemonEH

This project allows users to fetch Pokémon data from the [PokéAPI](https://pokeapi.co/docs/v2) and mark certain Pokémon as their favorites.

## Prerequisites

1. .NET 5.0 or later
2. An IDE such as Visual Studio or Visual Studio Code, although it's not strictly necessary.
3. SQLite (since the project uses SQLite as its database)

To set up the project, follow these steps:

1. Clone the repository:

```bash
  git clone https://github.com/Shumonov/pokemon-management-system.git
```

2. Navigate to the project directory:

```bash
  cd PokemonEH
```

3. Restore the required packages: .NET Core projects use NuGet packages, and you may need to restore them if they're not already included.

```bash
dotnet restore
```

3. Run the app locally:

```bash
dotnet run
```

## Usage

1. Register as a user.
2. Log in to access the Pokémon fetching and favorites features.
3. Fetch Pokémon data and add to your favorites list as needed.

Open [https://pokeapi.co/docs/v2](PokéAPI) to view it in the browser.

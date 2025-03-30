import { gql } from "@apollo/client";

export const GET_GAMES_BY_NAME = gql`
  query GetGamesByName($name: String!, $limit: Int!) {
    gamesByName(name: $name, limit: $limit) {
      id
      name
      firstReleaseDate
      releaseDates{
        id
      }
      platformsId
      platforms{
        id
      }
      cover{
        imageId
      }
      artworks{
        id
        imageId
      }
    }
  }
`;
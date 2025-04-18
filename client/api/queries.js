import { gql } from "@apollo/client";

export const GET_THREE_GAMES_BY_NAME = gql`
  query ThreeGamesByName($name: String!) {
    threeGamesByName(name: $name) {
      id
      name
      cover{
        imageId
      }
    }
  }
`;

export const GET_GAMES_BY_NAME = gql`
  query gamesByName($name: String!) {
    gamesByName(name: $name) {
      id
      name
      firstReleaseDate
      platforms{
        id
        name
        platformLogo{
          imageId
        }
      }
      cover{
        imageId
      }
      genres{
        id
        name
      }
    }
  }
`;

// 
// 
// platformsId
// platforms{
//   id
// }
// 
// artworks{
//   id
//   imageId
// }
// }
import { gql } from "@apollo/client";

export const GET_THREE_GAMES_BY_NAME = gql`
  query ThreeGamesByName($name: String!) {
    threeGamesByName(name: $name) {
      id
      name
      firstReleaseDate
      releaseDates{
        id
      }
      cover{
        imageId
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
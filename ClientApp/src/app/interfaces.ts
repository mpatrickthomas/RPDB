export interface Queen {
  queenId: number;
  name: string;
  hometown: string;
  notes: string;
  queenSeasons: QueenSeason[];
  queenGenres: QueenGenre[];
}

export interface QueenSeason {
  queenId: number;
  seasonId: number;
  season: Season;
}

export interface QueenGenre{
  queenId: number;
  genreId: number;
  genre: Genre;
}

export interface Genre {
  // TODO
}

export interface Season {
  seasonId: number;
  name: string;
  airDate: Date;
  notes: string;
}

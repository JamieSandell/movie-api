USE Movies

SET IDENTITY_INSERT dbo.Movies ON;

INSERT INTO dbo.Movies (
	Id,
	ReleaseDate,
	Title,
	Overview,
	Popularity,
	VoteCount,
	VoteAverage,
	OriginalLanguage,
	PosterURL
)
SELECT
	Id,
	ReleaseDate,
	Title,
	Overview,
	Popularity,
	VoteCount,
	VoteAverage,
	OriginalLanguage,
	PosterURL
FROM dbo.MoviesRaw;

SET IDENTITY_INSERT dbo.Movies OFF;

DROP TABLE IF EXISTS #Normalised;

CREATE TABLE #Normalised (
	MovieId INT,
	Title NVARCHAR(MAX),
	Genre NVARCHAR(MAX)
);

INSERT INTO #Normalised (
	MovieId,
	Title,
	Genre
)
SELECT
	M.Id MovieId,
	MR.Title,
	TRIM(GenreSplit.value) AS Genre
FROM dbo.MoviesRaw MR
INNER JOIN dbo.Movies M ON MR.Id = M.Id
CROSS APPLY STRING_SPLIT(MR.Genre, ',') AS GenreSplit;

INSERT INTO dbo.Genres (
	[Description]
)
SELECT DISTINCT Genre
FROM #Normalised;

INSERT INTO dbo.GenreMovie (
	GenresId,
	MovieId
)
SELECT
	G.Id,
	N.MovieId
FROM #Normalised N
INNER JOIN Genres G ON N.Genre = G.[Description];
import { useRouter } from "next/router"
import styles from "../styles/searchPage.module.scss"
import { useEffect, useState } from "react";
import { useLazyQuery, useQuery } from "@apollo/client";
import { GET_GAMES_BY_NAME } from "../api/queries";
import client from '../api/apolloClient';
import GameSearchCard from '../components/GameSearchCard'
import Loader from "../components/lotties/HandLoader";

export default function SearchResults() {
    const router = useRouter();
    const [searchQuery, setQuery] = useState('');
    const [gamesCount, setGameCount] = useState(0);
    const [page, setPage] = useState(1);

    const [fetchGames, { loading, error, data }] = useLazyQuery(GET_GAMES_BY_NAME, {
        client
    });

    useEffect(() => {
        if (router.isReady) {
            const searchQuery = router.query.query || '';
            const currentPage = parseInt(router.query.page) || 1;
            console.log(router.query);
            
            setQuery(router.query.query);
            setPage(currentPage);
            
            
            if (searchQuery) {
                console.log({ name: searchQuery, limit: 24, page: currentPage });
                
                fetchGames({ variables: { name: searchQuery, page: currentPage } });
            }
        }
    }, [router.isReady, router.query.query, router.query.page]);

    useEffect(() => {
        if (data?.gamesByName) {
            setGameCount(data.gamesByName.length);
            console.log(data.gamesByName);
        }

    }, [data]);

    return (
        <div>
            <div style={{marginLeft: '80px'}}>
                {loading && <Loader/>}
                {error && <h3 style={{marginLeft: '-80px'}}>{error.message}</h3>}
                {data?.gamesByName && 
                    <div>
                        <h2 style={{marginLeft: '-80px'}}>Games with similar name: {gamesCount}</h2>
                        <hr style={{margin: '0 auto', width: '90%'}}/>
                    </div>
                }
                <div className={styles.list}>
                    {data?.gamesByName.map(g => (
                        <GameSearchCard key={g.id} game={g} />
                    ))}
                </div>
                {data?.gamesByName.length > 0 && <div className={styles.nav}>
                    <button
                        onClick={() => {
                            if (page == 1) {
                                return;
                            }
                            router.push({
                                pathname: '/search',
                                query: {
                                  query: searchQuery,
                                  page: page - 1
                                }
                            });
                        }}
                    >&larr;</button>
                    <p>{page}</p>
                    <button
                        onClick={() => {
                            router.push({
                                pathname: '/search',
                                query: {
                                  query: searchQuery,
                                  page: page + 1
                                }
                            });
                        }}
                    >&rarr;</button>
                </div>}
            </div>
        </div>
    )
} 
import { useRouter } from 'next/router';
import { useEffect } from 'react';

export default function withAuth(Component) {
    return function ProtectedComponent(props) {
        const router = useRouter();

        useEffect(() => {
            const checkAuth = async () => {
                try {
                    const res = await fetch("http://localhost:5000/api/auth/validate", {
                        method: 'GET',
                        credentials: 'include'
                    })

                    if (res.status === 401) {
                        router.replace('/');
                    }
                } catch (err) {
                    router.replace('/');
                }
            };

            checkAuth();
        }, []);

        return <Component {...props} />;
    };
}

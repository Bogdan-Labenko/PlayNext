import { Provider, useDispatch } from 'react-redux';
import Layout from '../components/layout';
import '../styles/global.scss';
import { persistor, store } from '../store';
import { PersistGate } from 'redux-persist/integration/react';
import { useEffect } from 'react';
import { logout } from '../slices/userSlice';
import { useRouter } from 'next/router';

function TokenChecker({ children }) {
  const dispatch = useDispatch();
  const router = useRouter();
  useEffect(() => {
    fetch("http://localhost:5000/api/auth/validate", {
        method: 'GET',
        credentials: 'include'
    })
        .then(res => {
            if (res.status === 401) {
                dispatch(logout());
                router.push("/");
            }
        })
        .catch(() => {
            dispatch(logout())
            router.push("/");
        }
    );
    }, []);

  return children;
}

export default function App({ Component, pageProps }) {
  return (
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <TokenChecker>
          <Layout>
            <Component {...pageProps} />
          </Layout>
        </TokenChecker>
      </PersistGate>
    </Provider>
  );
}
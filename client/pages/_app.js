import { Provider } from 'react-redux';
import Layout from '../components/layout';
import '../styles/global.scss';
import { persistor, store } from '../store';
import { PersistGate } from 'redux-persist/integration/react';

export default function App({ Component, pageProps }) {
    return <Provider store={store}>
        <PersistGate loading={null} persistor={persistor}>
            <Layout>
                <Component {...pageProps} />
            </Layout>
        </PersistGate>
    </Provider>
}
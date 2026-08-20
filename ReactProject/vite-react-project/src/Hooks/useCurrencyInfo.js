import { useState, useEffect } from 'react';

function useCurrencyInfo(currency) {
    const [data, setData] = useState({ rates: {} });

    useEffect(() => {
        const controller = new AbortController();

        fetch(`https://api.frankfurter.app/latest?from=${currency.toUpperCase()}`, {
            signal: controller.signal,
        })
            .then((res) => res.json())
            .then((res) => setData(res))
            .catch((error) => {
                if (error.name !== 'AbortError') {
                    console.error(error);
                }
            });

        return () => controller.abort();
    }, [currency]);

    return data;
}

export default useCurrencyInfo;
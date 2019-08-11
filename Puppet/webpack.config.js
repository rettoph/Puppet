var path = require('path')
var webpack = require('webpack')
const { VueLoaderPlugin } = require('vue-loader')


module.exports = (env) => {
    var mode = env === 'Release' ? 'production' : 'development';

    return {
        mode: mode,
        entry: path.resolve(__dirname, 'src/js/app.js'),
        output: {
            path: path.resolve(__dirname, './public'),
            publicPath: '/',
            filename: 'app.js'
        },
        module: {
            rules: [
                {
                    test: /\.vue\.html$/,
                    loader: 'vue-loader'
                }
            ]
        },
        resolve: {
            alias: {
                'vue': 'vue/dist/vue.js'
            },
            extensions: ['*', '.js', '.vue', '.json']
        },
        plugins: [
            new webpack.DefinePlugin({
                'process.env.NODE_ENV': JSON.stringify(mode)
            }),
            new VueLoaderPlugin()
        ]
    };
}
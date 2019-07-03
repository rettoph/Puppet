var path = require('path')
var webpack = require('webpack')
const { VueLoaderPlugin } = require('vue-loader')

module.exports = {
  entry: path.resolve(__dirname, 'src/js/app.js'),
  output: {
    path: path.resolve(__dirname, './public'),
    publicPath: '/',
    filename: 'app.js'
  },
  module: {
    rules: [
	  {
        test: /\.vue$/,
        loader: 'vue-loader'
      }
    ]
  },
  resolve: {
    alias: {
      'vue$': 'vue/dist/vue.esm.js'
    },
    extensions: ['*', '.js', '.vue', '.json']
  },
  plugins: [
	new VueLoaderPlugin()
  ]
}
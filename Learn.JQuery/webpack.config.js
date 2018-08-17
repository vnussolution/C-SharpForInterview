﻿const path = require('path');

module.exports = {
    entry: ['./Scripts/es6/main.js'],
    output: {
        path: path.resolve(__dirname, './Scripts/build'),
        filename: 'bundle.js'
    },
    // IMPORTANT NOTE: If you are using Webpack 2, replace "loaders" with "rules"
    module: {
        rules: [
            {
                loader: 'babel-loader',
                test: /\.js$/,
                exclude: /node_modules/
            }
        ]
    }
}
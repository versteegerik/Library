const webpack = require("webpack");
const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const UglifyJsPlugin = require("uglifyjs-webpack-plugin");
const OptimizeCssAssetsPlugin = require("optimize-css-assets-webpack-plugin");

var config = {
    entry: {
        bundle: "./Resources/App.ts"
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/dist"),
        filename: "[name].js"
    },
    resolve: {
        extensions: [".tsx", ".ts", ".js"]
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/, //compile TypeScript to JavaScript
                use: "ts-loader",
                exclude: /node_modules/
            }, {
                test: /\.s?[ac]ss$/, //compile SASS to css file
                use: [
                    MiniCssExtractPlugin.loader,
                    { loader: "css-loader", options: { sourceMap: true } },
                    { loader: 'postcss-loader' },
                    { loader: 'sass-loader', options: { sourceMap: true } }
                ]
            }, {
                test: /.(ttf|otf|eot|svg|woff(2)?)(\?[a-z0-9]+)?$/, //output font files in font folder
                use: [
                    { loader: "file-loader", options: { name: "[name].[ext]", outputPath: "fonts/" } }
                ]
            }
        ]
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            'window.jQuery': "jquery",
            Popper: ["popper.js", "default"],
            moment: "moment"
        }),
        new MiniCssExtractPlugin(),
        new webpack.optimize.LimitChunkCountPlugin({
            maxChunks: 1 //disable chunking
        })
    ]
};

module.exports = (env, argv) => {

    if (argv.mode === "development") {
        config.devtool = "source-map"; //generate source
    }

    if (argv.mode === "production") {
        config.optimization = {
            minimizer: [
                new UglifyJsPlugin({
                    parallel: true,
                    sourceMap: true
                }),
                new OptimizeCssAssetsPlugin({})
            ]
        };
    }

    return config;
};
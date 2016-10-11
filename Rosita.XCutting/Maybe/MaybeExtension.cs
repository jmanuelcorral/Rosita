using System;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Rosita.XCutting.Maybe
{
    public static class MaybeExtension
    {
        public static Maybe<TReturn> Select<TInput, TReturn>(
            this Maybe<TInput> input,
            Func<TInput, TReturn> selectEvaluator)
        {
            return input.HasValue
                ? selectEvaluator(input.Value).ToMaybe()
                : Maybe<TReturn>.Nothing;
        }

        public static Maybe<TReturnType> SelectOrDefault<TInput, TReturnType>(
            this Maybe<TInput> input,
            Func<TInput, TReturnType> selectEvaluator,
            Func<TReturnType> selectDefault)
        {
            var result = input.Select(selectEvaluator);

            return result.HasValue
                ? result
                : selectDefault().ToMaybe();
        }

        public static TReturnType Return<TInput, TReturnType>(
            this Maybe<TInput> input,
            Func<TInput, TReturnType> selectEvaluator,
            Func<TReturnType> selectDefault)
        {
            if (input.HasValue)
            {
                var maybe = selectEvaluator.Invoke(input.Value).ToMaybe();
                return maybe.HasValue
                    ? maybe.Value
                    : selectDefault();
            }

            return selectDefault();
        }

        public static Maybe<T> ToMaybe<T>(this T input)
        {
            return typeof(T).GetTypeInfo().IsValueType
                ? new Maybe<T>(input, true)
                : new Maybe<T>(input, input != null);
        }

        [Pure]
        public static Maybe<T> If<T>(this Maybe<T> input, Func<T, bool> condition)
        {
            if (input.HasValue)
            {
                return condition(input.Value)
                    ? input
                    : Maybe<T>.Nothing;
            }

            return input;
        }

        [Pure]
        public static Maybe<T> Execute<T>(this Maybe<T> input, Action<T> doAction)
        {
            if (input.HasValue)
            {
                doAction.Invoke(input.Value);
            }

            return input;
        }
    }
}
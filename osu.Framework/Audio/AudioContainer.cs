// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osuTK;

namespace osu.Framework.Audio
{
    public class AudioContainer<T> : DrawableAudioWrapper, IContainerEnumerable<T>, IContainerCollection<T>, ICollection<T>, IReadOnlyList<T>
        where T : Drawable
    {
        private static Container<T> container;

        public AudioContainer()
            : base(container = new Container<T>())
        {
        }

        public override Vector2 Size
        {
            get => container.Size;
            set
            {
                base.Size = new Vector2(
                    RelativeSizeAxes.HasFlag(Axes.X) ? 1 : value.X,
                    RelativeSizeAxes.HasFlag(Axes.Y) ? 1 : value.Y);

                container.Size = value;
            }
        }

        public override Axes RelativeSizeAxes
        {
            get => container.RelativeSizeAxes;
            set
            {
                base.RelativeSizeAxes = value;
                container.RelativeSizeAxes = value;
            }
        }

        public new Axes AutoSizeAxes
        {
            get => container.AutoSizeAxes;
            set
            {
                base.AutoSizeAxes = value;
                container.AutoSizeAxes = value;
            }
        }

        public new EdgeEffectParameters EdgeEffect
        {
            get => base.EdgeEffect;
            set => base.EdgeEffect = value;
        }

        public new Vector2 RelativeChildSize
        {
            get => container.RelativeChildSize;
            set => container.RelativeChildSize = value;
        }

        public new Vector2 RelativeChildOffset
        {
            get => container.RelativeChildOffset;
            set => container.RelativeChildOffset = value;
        }

        public Container<T>.Enumerator GetEnumerator() => container.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IReadOnlyList<T> Children
        {
            get => container.Children;
            set => container.Children = value;
        }

        public int RemoveAll(Predicate<T> match) => container.RemoveAll(match);

        public T Child
        {
            get => container.Child;
            set => container.Child = value;
        }

        public IEnumerable<T> ChildrenEnumerable
        {
            set => container.ChildrenEnumerable = value;
        }

        public void Add(T drawable)
        {
            container.Add(drawable);
        }

        public void Clear()
        {
            container.Clear();
        }

        public bool Contains(T item) => container.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            container.CopyTo(array, arrayIndex);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            container.AddRange(collection);
        }

        public bool Remove(T drawable) => container.Remove(drawable);
        int ICollection<T>.Count => container.Count;

        public bool IsReadOnly => container.IsReadOnly;

        public void RemoveRange(IEnumerable<T> range)
        {
            container.RemoveRange(range);
        }

        int IReadOnlyCollection<T>.Count => container.Count;

        public T this[int index] => container[index];
    }

    public class AudioContainer : AudioContainer<Drawable>
    {
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Some.Tools
{
    // code from https://stackoverflow.com/a/13776636
    
    public class MaxHeap<T> : Heap<T> where T : IComparable<T>
    {
        public MaxHeap()
            : this(Comparer<T>.Default)
        {
        }

        public MaxHeap(Comparer<T> comparer)
            : base(comparer)
        {
        }

        public MaxHeap(IEnumerable<T> collection, Comparer<T> comparer)
            : base(collection, comparer)
        {
        }

        public MaxHeap(IEnumerable<T> collection) : base(collection)
        {
        }

        protected override bool Dominates(T x, T y)
        {
            return Comparer.Compare(x, y) >= 0;
        }
    }

    public class MinHeap<T> : Heap<T> where T : IComparable<T>
    {
        public MinHeap()
            : this(Comparer<T>.Default)
        {
        }

        public MinHeap(Comparer<T> comparer)
            : base(comparer)
        {
        }

        public MinHeap(IEnumerable<T> collection) : base(collection)
        {
        }

        public MinHeap(IEnumerable<T> collection, Comparer<T> comparer)
            : base(collection, comparer)
        {
        }

        protected override bool Dominates(T x, T y)
        {
            return Comparer.Compare(x, y) <= 0;
        }
    }
    
    public abstract class Heap<T> : IEnumerable<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 0;
        private const int GrowFactor = 2;
        private const int MinGrow = 1;

        private T[] _heap = new T[InitialCapacity];

        public int Count { get; private set; }

        public int Capacity { get; private set; } = InitialCapacity;

        protected Comparer<T> Comparer { get; }
        protected abstract bool Dominates(T x, T y);

        protected Heap() : this(Comparer<T>.Default)
        {
        }

        protected Heap(Comparer<T> comparer) : this(Enumerable.Empty<T>(), comparer)
        {
        }

        protected Heap(IEnumerable<T> collection)
            : this(collection, Comparer<T>.Default)
        {
        }

        protected Heap(IEnumerable<T> collection, Comparer<T> comparer)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));

            foreach (var item in collection)
            {
                if (Count == Capacity)
                    Grow();

                _heap[Count++] = item;
            }

            for (var i = Parent(Count - 1); i >= 0; i--)
                BubbleDown(i);
        }

        public void Add(T item)
        {
            if (Count == Capacity)
                Grow();

            _heap[Count++] = item;
            BubbleUp(Count - 1);
        }

        private void BubbleUp(int i)
        {
            var safetyCounter = Count;
            while (safetyCounter-- > 0)
            {
                if (i == 0 || Dominates(_heap[Parent(i)], _heap[i])) return; //correct domination (or root)

                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public T GetRoot()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty");
            return _heap[0];
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty");
            T ret = _heap[0];
            Count--;
            Swap(Count, 0);
            BubbleDown(0);
            return ret;
        }

        private void BubbleDown(int i)
        {
            var dominatingNode = Dominating(i);
            if (dominatingNode == i) return;
            Swap(i, dominatingNode);
            BubbleDown(dominatingNode);
        }

        private int Dominating(int i)
        {
            var dominatingNode = i;
            dominatingNode = GetDominating(YoungChild(i), dominatingNode);
            dominatingNode = GetDominating(OldChild(i), dominatingNode);

            return dominatingNode;
        }

        private int GetDominating(int newNode, int dominatingNode)
        {
            if (newNode < Count && !Dominates(_heap[dominatingNode], _heap[newNode]))
                return newNode;
            return dominatingNode;
        }

        private void Swap(int i, int j)
        {
            T tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        private static int Parent(int i)
        {
            return (i + 1) / 2 - 1;
        }

        private static int YoungChild(int i)
        {
            return (i + 1) * 2 - 1;
        }

        private static int OldChild(int i)
        {
            return YoungChild(i) + 1;
        }

        private void Grow()
        {
            int newCapacity = Capacity * GrowFactor + MinGrow;
            var newHeap = new T[newCapacity];
            Array.Copy(_heap, newHeap, Capacity);
            _heap = newHeap;
            Capacity = newCapacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _heap.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
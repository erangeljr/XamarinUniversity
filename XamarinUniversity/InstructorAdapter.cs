using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using System.IO;
using Android.Graphics.Drawables;

namespace XamarinUniversity
{
	public class InstructorAdapter : BaseAdapter<Instructor>
	{
		Activity context;
		List<Instructor> instructors;


		public InstructorAdapter(Activity context, List<Instructor> instructors)
		{
			this.context = context;
			this.instructors = instructors;
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var view = convertView;

			if (view == null)
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.InstructorRow, parent, false);

				var p = view.FindViewById<ImageView>(Resource.Id.photoImageView);
				var n = view.FindViewById<TextView >(Resource.Id.nameTextView);
				var s = view.FindViewById<TextView >(Resource.Id.specialtyTextView);

				view.Tag = new ViewHolder() { Photo = p, Name = n, Specialty = s };
			}

			var holder = (ViewHolder)view.Tag;

			holder.Photo.SetImageDrawable(ImageAssetManager.Get(context, instructors[position].ImageUrl));
			holder.Name     .Text = instructors[position].Name;
			holder.Specialty.Text = instructors[position].Specialty;

			return view;
		}

		public override int Count
		{
			get
			{
				return instructors.Count;
			}
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override Instructor this[int index]
		{
			get
			{
				return instructors[index];
			}
		}

		#endregion

		// ISectionIndexer implementation

		Java.Lang.Object[]   sectionHeaders        = SectionIndexerBuilder.BuildSectionHeaders       (InstructorData.Instructors);
		Dictionary<int, int> positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(InstructorData.Instructors);
		Dictionary<int, int> sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(InstructorData.Instructors);

		public Java.Lang.Object[] GetSections()
		{
			return sectionHeaders;
		}

		public int GetPositionForSection(int section)
		{
			return positionForSectionMap[section];
		}

		public int GetSectionForPosition(int position)
		{
			return sectionForPositionMap[position];
		}
	
	}
}


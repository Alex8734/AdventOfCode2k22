using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Day7;

public class FileSystem
{
    
    public Day7.Directory CurrentDirectory { get; private set; }

    public Day7.Directory Root
    {
        get
        {
            var temp = CurrentDirectory;
            while (temp.ParentDirectory != null)
            {
                temp = temp.ParentDirectory;
            }

            return temp;
        }
    }
    public FileSystem()
    {
        CurrentDirectory = new Day7.Directory(null, "/", new List<Day7.Directory>());
    }

    public void CD(string name)
    {
        if (name == "..")
        {
            if(CurrentDirectory.ParentDirectory != null)
                CurrentDirectory = CurrentDirectory.ParentDirectory!;
            return;
        }
        foreach (var dir in CurrentDirectory.Childes)
        {
            if (dir.Name == name)
            {
                CurrentDirectory = dir;
                return;
            }
        }

        var newDir = new Directory(CurrentDirectory, name, new List<Directory>());
        CurrentDirectory.Add(newDir);
        CurrentDirectory = newDir;
    }
}
public class File : Directory
{
    public override int Size { get; }

    public override Type Type { get; }

    public File(Directory parentDirectory, string name,int size)
       : base(parentDirectory,name,null)
    {
       Size = size;
       Type = Type.File;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class Directory
{
    public Directory? ParentDirectory { get; }
    public string Name { get; }
    public virtual Type Type{get;}
    public virtual int Size
    {
        get
        {
            int size = 0;
            foreach (var child in Childes)
            {
                size += child.Size;
            }

            return size;
        }
    }
    public List<Directory>? Childes { get; set; }
    public Directory(Directory parentDirectory, string name, List<Directory> childes)
    {
        ParentDirectory = parentDirectory;
        Name = name;
        Childes = childes;
        Type = Type.Directory;
    }

    public void Add(Directory d)
    {
        Childes.Add(d);
    }

    public bool HasDirOrFile(string name)
    {
        foreach (var child in Childes)
        {
            if (child.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        return Name;
    }
}

public enum Type
{
    File,
    Directory
}



